# importing the Dataset
import pandas as pd

#csv file is tab-separated, has 2 columns and there is no names to columns, so adding names 
messages = pd.read_csv('C:/Users/Rajkumar/Desktop/Python/chatbot/NLP/SMSSpamCollection.csv', sep='\t',
                       names=["label", "message"])

#Data cleaning and preprocessing
import re
import nltk

# To download all packages inside nltk
#nltk.download()

from nltk.corpus import stopwords
from nltk.stem import PorterStemmer
ps = PorterStemmer()


# from nltk.stem import WordNetLemmatizer
# wordnet = WordNetLemmatizer()

corpus = []

for i in range(0, len(messages)):
    review = re.sub('[^a-zA-Z]', ' ', messages['message'][i])
    review = review.lower()
    review = review.split()

	# Stemming Process    
    review = [ps.stem(word) for word in review if not word in stopwords.words('english')]
    
	# Lemmatization Process   
    #review = [wordnet.lemmatize(word) for word in review if not word in stopwords.words('english')]

    review = ' '.join(review)
    corpus.append(review)
    
#Creating the Bag of Words model
from sklearn.feature_extraction.text import CountVectorizer
cv = CountVectorizer(max_features=5000)

# Creating the TF-IDF model
# from sklearn.feature_extraction.text import TfidfVectorizer
# cv = TfidfVectorizer()

X = cv.fit_transform(corpus).toarray()

# Changing label column (spam and ham) to 0 and 1
y=pd.get_dummies(messages['label'])

#reducing label to 1 column; 0=ham, 1 = spam
y=y.iloc[:,1].values

#Train Test Split 80:20
from sklearn.model_selection import train_test_split
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size = 0.20, random_state = 0)

#Training model using Naive Bayes Classifier
from sklearn.naive_bayes import MultinomialNB
spam_detect_model = MultinomialNB().fit(X_train, y_train)

y_pred = spam_detect_model.predict(X_test)

#Confusion matrix
from sklearn.metrics import confusion_matrix
confusion_m=confusion_matrix(y_test, y_pred)
print('Confusion Matrix:')
print(confusion_m)

#Accuracy Score
from sklearn.metrics import accuracy_score
accuracy = accuracy_score(y_test, y_pred)
print('Accuracy: ', end=" ")
print(accuracy)

#Testing model with real-world examples
examples = ['God Father', 'you have a free offer', 'join for free', 'You have to come to office tomorrow']
example_counts = cv.transform(examples)
predictions = spam_detect_model.predict(example_counts)
print(['This is Spam' if predictions[i]== 1 else 'This is Ham' for i in range(len(predictions))])

  
	