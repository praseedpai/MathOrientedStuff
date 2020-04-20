import sys
from sys import exit



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

# bubbleSort(numbers)

n = len(numbers)
 
    # Traverse through all array elements
for i in range(n):
 
 # Last i elements are already in place
	for j in range(0, n-i-1):
 
            # traverse the array from 0 to n-i-1
            # Swap if the element found is greater
            # than the next element
            if numbers[j] > numbers[j+1] :
                numbers[j], numbers[j+1] = numbers[j+1], numbers[j]



print(numbers)






