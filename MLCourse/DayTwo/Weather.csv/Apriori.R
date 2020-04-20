http://r-statistics.co/Association-Mining-With-R.html

install.packages("arules")

library(arules)
data("Adult")
rules <- apriori(Adult,parameter = list(supp = 0.5, conf = 0.9, target = "rules"))
summary(rules)
inspect(rules) #It gives the list of all significant association rules. Some of them are shown below
dataset = [['Milk', 'Onion', 'Nutmeg', 'Kidney Beans', 'Eggs', 'Yogurt'],
           ['Dill', 'Onion', 'Nutmeg', 'Kidney Beans', 'Eggs', 'Yogurt'],
           ['Milk', 'Apple', 'Kidney Beans', 'Eggs'],
           ['Milk', 'Unicorn', 'Corn', 'Kidney Beans', 'Yogurt'],
           ['Corn', 'Onion', 'Onion', 'Kidney Beans', 'Ice cream', 'Eggs']]
