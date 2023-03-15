const int NUM_POINTS = 5;  // Number of data points
double x[] = {0.0, 1.0, 2.0, 3.0, 4.0};  // x-values (alcohol concentrations)
double y[] = {0.0, 1.0, 4.0, 9.0, 16.0};  // y-values (analog outputs)
double a, b, c;  // Parameters for the curve fitting function

double curve(double x, double a, double b, double c) {
  // Define the curve fitting function
  return a * x * x + b * x + c;
}

double sumSquares(double x[], double y[], int n, double a, double b, double c) {
  // Calculate the sum of the squares of the residuals
  double sum = 0;
  for (int i = 0; i < n; i++) {
    double residual = y[i] - curve(x[i], a, b, c);
    sum += residual * residual;
  }
  return sum;
}

void leastSquares(double x[], double y[], int n, double* a, double* b, double* c) {
  // Use the "least squares" method to find the parameters that minimize the sum of the squares of the residuals
  double sumX = 0, sumY = 0, sumXY = 0, sumX2 = 0, sumX3 = 0, sumX4 = 0, sumX5 = 0, sumX6 = 0, sumYX2 = 0, sumYX = 0;
  for (int i = 0; i < n; i++) {
    sumX += x[i];
    sumY += y[i];
    sumXY += x[i] * y[i];
    sumX2 += x[i] * x[i];
    sumX3 += x[i] * x[i] * x[i];
    sumX4 += x[i] * x[i] * x[i] * x[i];
    sumX5 += x[i] * x[i] * x[i] * x[i] * x[i];
    sumX6 += x[i] * x[i] * x[i] * x[i] * x[i] * x[i];
    sumYX2 += y[i] * x[i] * x[i];
    sumYX += y[i] * x[i];
  }
  double c1 = (n * sumYX2 + sumX * sumYX - sumX2 * sumY) / (n * sumX4 + 2 * sumX2 * sumX2 - sumX5 - sumX3 * sumX);
  double c2 = (sumY - c1 * sumX3 - sumXY * sumX) / (n * sumX2 - sumX * sumX);
  *a = c1 / 2;
  *b = c2;
  *c = (sumY - *a * sumX4 - *b * sumX2) / n;
}

void InitializeLeastSquares(){
  // Fit a curve to the data points using the "least squares" method
  leastSquares(x, y, NUM_POINTS, &a, &b, &c);  // <-- Fit the curve using the "least squares" method
}