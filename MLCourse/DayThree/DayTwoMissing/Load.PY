import pandas as pd 

# reading csv file 
data = pd.read_csv('weather.csv') 

# shape of dataset 
print("Shape:", data.shape) 

# column names 
print("\nFeatures:", data.columns) 

# storing the feature matrix (X) and response vector (y) 
X = data[data.columns[:-1]] 
y = data[data.columns[-1]] 

# printing first 5 rows of feature matrix 
print("\nFeature matrix:\n", X.head()) 

# printing first 5 values of response vector 
print("\nResponse vector:\n", y.head())
