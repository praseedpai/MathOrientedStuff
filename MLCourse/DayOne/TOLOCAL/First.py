# Common imports
import numpy as np
import os


import tarfile

# to make this notebook's output stable across runs
np.random.seed(42)

# To plot pretty figures

import matplotlib as mpl
import matplotlib.pyplot as plt
mpl.rc('axes', labelsize=14)
mpl.rc('xtick', labelsize=12)
mpl.rc('ytick', labelsize=12)

import pandas as pd

def load_housing_data(housing_path=""):
    csv_path = os.path.join("", "housing.csv")
    return pd.read_csv(csv_path)

housing = load_housing_data()
print(housing.head())

#------------------------- Step 2

housing.info()


import matplotlib.pyplot as plt
#housing.hist(bins=50, figsize=(20,15))
#plt.show()


housing.describe()


#----------------------- Step 3


# For illustration only. Sklearn has train_test_split()
def split_train_test(data, test_ratio):
    shuffled_indices = np.random.permutation(len(data))
    test_set_size = int(len(data) * test_ratio)
    test_indices = shuffled_indices[:test_set_size]
    train_indices = shuffled_indices[test_set_size:]
    return data.iloc[train_indices], data.iloc[test_indices]

train_set, test_set = split_train_test(housing, 0.2)
print(len(train_set), "train +", len(test_set), "test")




#------------------ Step 4

from zlib import crc32

def test_set_check(identifier, test_ratio):
    return crc32(np.int64(identifier)) & 0xffffffff < test_ratio * 2**32

def split_train_test_by_id(data, test_ratio, id_column):
    ids = data[id_column]
    in_test_set = ids.apply(lambda id_: test_set_check(id_, test_ratio))


housing_with_id = housing.reset_index()   # adds an `index` column
#train_set, test_set = split_train_test_by_id(housing_with_id, 0.2, "index")


housing_with_id["id"] = housing["longitude"] * 1000 + housing["latitude"]
#train_set, test_set = split_train_test_by_id(housing_with_id, 0.2, "id")

from sklearn.model_selection import train_test_split

train_set, test_set = train_test_split(housing, test_size=0.2, random_state=42)
print(test_set.head())

#housing.hist()
#housing["median_income"].hist()
housing.plot(kind="scatter", x="longitude", y="latitude")
plt.show()



