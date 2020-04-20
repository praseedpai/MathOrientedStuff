from sklearn import linear_model
import numpy as np
import pandas as pd

from sklearn import datasets 
data = datasets.load_boston() 


df = pd.DataFrame(data.data, columns=data.feature_names)


target = pd.DataFrame(data.target, columns=["MEDV"])

X = df
y = target["MEDV"]

lm = linear_model.LinearRegression()
model = lm.fit(X,y)

predictions = lm.predict(X)
print(predictions)[0:5]

lm.score(X,y)

lm.coef_


lm.intercept_

