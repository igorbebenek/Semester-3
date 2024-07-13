n=10
A=rand(n,n)
E=eye(n)
A=A+n*E
x=ones(n,1)
b=A*x
e=0.01;
tic
iterP(A,b,n,e)
toc







