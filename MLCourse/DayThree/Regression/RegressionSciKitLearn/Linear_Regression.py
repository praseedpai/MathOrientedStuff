from numpy.linalg import inv
from numpy import dot, transpose
X = [[1, 6, 2], [1, 8, 1], [1, 10, 0], [1, 14, 2], [1, 18, 0]]
y = [[7], [9], [13], [17.5], [18]]

#---- Composite Formulation
print dot(inv(dot(transpose(X), X)), dot(transpose(X), y))

op1 = transpose(X)  // 
op2 = dot( op1 , X )
op3 = dot( op1 , y )

op4 = inv( op2 )
op5 = dot( op4, op3)

print(