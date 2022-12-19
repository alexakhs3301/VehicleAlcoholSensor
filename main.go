package main

import (
	"database/sql"
	"encoding/json"
	"errors"
	"github.com/spf13/viper"
	"net/http"
	"strconv"
	"time"
)

type Metric struct {
	ID              int
	VehicleDriverId int
	Percentage      float64
	CreatedOn       time.Time
	UpdatedOn       time.Time
	IsDeleted       bool
}

type Vehicle struct {
	ID           int
	LicensePlate string
	CreatedOn    time.Time
	UpdatedOn    time.Time
	IsDeleted    bool
}
type VehicleDriver struct {
	ID        int
	driverID  int
	vehicleID int
	CreatedOn time.Time
	UpdatedOn time.Time
	IsDeleted bool
}

var pgDB *sql.DB

func main() {

	/*reading from json config file using viper package*/
	viper.AddConfigPath("./")
	viper.SetConfigName("dbConfig")
	viper.SetConfigType("json")
	err := viper.ReadInConfig()
	if err != nil {
		errors.New("cannot read from config file")
	}

	pgDsn := viper.GetString("postgresData.dataSourceName")

	pgDB, err := sql.Open("postgres", pgDsn)
	if err != nil {
		panic(err)
	}
	err = pgDB.Ping()
	if err != nil {
		panic(err)
	}

	http.HandleFunc("/sensordata", handlePOSTSensorData)
	http.HandleFunc("/sensordata", handleGETSensorData)
	http.ListenAndServe(":8080", nil)
}

func handleGETSensorData(w http.ResponseWriter, r *http.Request) {
	if r.Method != http.MethodGet {
		http.Error(w, "Invalid request method", http.StatusMethodNotAllowed)
		return
	}

	queryParams := r.URL.Query()
	driverIDstr := queryParams.Get("driverID")
	vehicleIDstr := queryParams.Get("vehicleID")

	var driverID int
	var vehicleID int
	var err error

	driverID, err = strconv.Atoi(driverIDstr)
	if err != nil {
		http.Error(w, "Error parsing driverID",
			http.StatusBadRequest)
		return
	}

	vehicleID, err = strconv.Atoi(vehicleIDstr)
	if err != nil {
		http.Error(w, "Error parsing vehicleID",
			http.StatusBadRequest)
		return
	}

	rows, err := pgDB.Query("SELECT * FROM metric_getall_by_driverid_and_vehicle_id($1,$2)", driverID, vehicleID)
	if err != nil {
		http.Error(w, "Error fetching metrics from database", http.StatusInternalServerError)
		return
	}
	defer rows.Close()

	metrics := []Metric{}
	for rows.Next() {
		var m Metric
		if err := rows.Scan(&m.ID, &m.VehicleDriverId, &m.Percentage, &m.CreatedOn, &m.UpdatedOn, &m.IsDeleted); err != nil {
			http.Error(w, "Error scanning metric rows", http.StatusInternalServerError)
			return
		}
		metrics = append(metrics, m)
	}

	if err := rows.Err(); err != nil {
		http.Error(w, "Error fetching metric rows", http.StatusInternalServerError)
		return
	}

	w.Header().Set("Content-Type", "application/json")
	json.NewEncoder(w).Encode(metrics)
}

func handlePOSTSensorData(w http.ResponseWriter, r *http.Request) {
	if r.Method != http.MethodPost {
		http.Error(w, "Invalid request method", http.StatusMethodNotAllowed)
		return
	}

	var m Metric
	if err := json.NewDecoder(r.Body).Decode(&m); err != nil {
		http.Error(w, "Error decoding metric JSON", http.StatusBadRequest)
		return
	}

	now := time.Now()
	m.CreatedOn = now
	m.UpdatedOn = now

	_, err := pgDB.Exec("SELECT * FROM metric_insert($1, $2, $3)", m.VehicleDriverId, m.ID, m.Percentage)
	if err != nil {
		http.Error(w, "Error inserting metric into database", http.StatusInternalServerError)
		return
	}

	w.WriteHeader(http.StatusCreated)
}
