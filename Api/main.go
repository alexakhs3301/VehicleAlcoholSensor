package main

import (
	"database/sql"
	"encoding/json"
	"errors"
	"log"
	"net/http"
	"strconv"

	_ "github.com/lib/pq"
	"github.com/spf13/viper"
)

type metric struct {
	Percentage     float64 `json:"percentage"`
	EventTimestamp string  `json:"event_timestamp"`
}

type HR struct {
	DriverID   int
	VehicleID  int
	Percentage float64
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

	pgDB, err = sql.Open("postgres", pgDsn)
	if err != nil {
		panic(err)
	}
	err = pgDB.Ping()
	if err != nil {
		panic(err)
	}

	http.HandleFunc("/sensordatapost", handlePOSTSensorData)
	http.HandleFunc("/sensordataget", handleGETSensorData)
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
		log.Println(err)
		http.Error(w, "Error fetching metrics from database", http.StatusInternalServerError)
		return
	}
	defer rows.Close()

	var metrics []metric
	for rows.Next() {
		var m metric
		if err = rows.Scan(&m.Percentage, &m.EventTimestamp); err != nil {
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
	err = json.NewEncoder(w).Encode(metrics)

	if err != nil {
		http.Error(w, err.Error(), http.StatusInternalServerError)
		return
	}
}

func handlePOSTSensorData(w http.ResponseWriter, r *http.Request) {
	if r.Method != http.MethodPost {
		http.Error(w, "Invalid request method", http.StatusMethodNotAllowed)
		return
	}

	var h HR
	if err := json.NewDecoder(r.Body).Decode(&h); err != nil {
		http.Error(w, "Error decoding metric JSON", http.StatusBadRequest)
		return
	}

	_, err := pgDB.Exec("SELECT * FROM metric_insert($1, $2, $3)", &h.DriverID, &h.VehicleID, &h.Percentage)
	if err != nil {
		http.Error(w, "Error inserting metric into database", http.StatusInternalServerError)
		return
	}

	w.WriteHeader(http.StatusCreated)
}
