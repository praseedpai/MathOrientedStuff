import sys
from sys import exit

def bubbleSort(arr):
    n = len(arr)
 
    # Traverse through all array elements
    for i in range(n):
 
        # Last i elements are already in place
        for j in range(0, n-i-1):
 
            # traverse the array from 0 to n-i-1
            # Swap if the element found is greater
            # than the next element
            if arr[j] > arr[j+1] :
                arr[j], arr[j+1] = arr[j+1], arr[j]




if len(sys.argv) == 1 :
	print ("No command line argument" )
	sys.exit()
#else :
#        print ("rest of the program ")

#numbers = sys.argv[1:]
#print (sorted(numbers, key=lambda x: float(x)))

numbers = []

i=1
n= len(sys.argv)

while ( i < n ):
	numbers.append(sys.argv[i])
	i=i+1

bubbleSort(numbers)




print(numbers)






