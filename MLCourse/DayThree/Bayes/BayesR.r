library(e1071)


mydata = read.csv("D:/SUYATI/SLIDES/DayTwo/Weather.csv/Bayes.csv")  # read csv file 
model <- naiveBayes(Gender ~ Gender+height+weight+foot.size, data =mydata)
model

#----- 6 130 8

df <-  edit(data.frame())
pred <- predict(model, df[,-1])
df[,-1]
pred

 
