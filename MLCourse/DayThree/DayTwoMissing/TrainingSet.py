# load the iris dataset as an example 
from sklearn.datasets import load_iris 
from pandas.plotting import scatter_matrix 
import matplotlib.pyplot as plt 
from sklearn import model_selection 
from sklearn.metrics import classification_report 
from sklearn.metrics import confusion_matrix 
from sklearn.metrics import accuracy_score 
from sklearn.linear_model import LogisticRegression 
from sklearn.tree import DecisionTreeClassifier 
from sklearn.neighbors import KNeighborsClassifier 
from sklearn.discriminant_analysis import LinearDiscriminantAnalysis 
from sklearn.naive_bayes import GaussianNB 
from sklearn.svm import SVC 


import pandas as pd 

# reading csv file 
data = pd.read_csv('Iris.csv') 

# shape of dataset 
print("Shape:", data.shape) 

# column names 
print("\nFeatures:", data.columns) 

# head 
print(data.head(20)) 

#
print(data.describe)
# class distribution 
print(data.groupby('variety').size()) 

# box and whisker plots 
data.plot(kind ='box', subplots = True, 
			layout =(2, 2), sharex = False, sharey = False) 
plt.show() 


# storing the feature matrix (X) and response vector (y) 
X = data[data.columns[:-1]] 
y = data[data.columns[-1]] 


# splitting X and y into training and testing sets 
from sklearn.model_selection import train_test_split 
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.4, random_state=1) 

#print(X_train)
#print(X_test)

# Make predictions on validation dataset 
knn = KNeighborsClassifier() 
knn.fit(X_train, y_train) 
predictions = knn.predict(X_test) 
print(accuracy_score(y_test, predictions)) 
print(confusion_matrix(y_test, predictions)) 
print(classification_report(y_test, predictions)) 

# Make predictions on validation dataset 
knn = DecisionTreeClassifier() 
knn.fit(X_train, y_train) 
predictions = knn.predict(X_test) 
print(accuracy_score(y_test, predictions)) 
print(confusion_matrix(y_test, predictions)) 
print(classification_report(y_test, predictions)) 










