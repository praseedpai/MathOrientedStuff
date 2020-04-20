import sys

print ('Number of arguments:', len(sys.argv), 'arguments.')
print ('Argument List:', str(sys.argv))

if len(sys.argv) == 1 :
	print ("No command line argument" )
else:
	print("There is indeed command line argument " )

print ("End of Program " )


