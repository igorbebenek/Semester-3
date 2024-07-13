function x = iterP(A,b,n,e)
Ab = [A b];
licznik=0;
for i = 1:n
    Ab(i,:) = Ab(i,:)./Ab(i,i);
    Ab(i,1:n) = Ab(i,1:n)*-1;
    Ab(i,i)=0;
end
w=Ab(:,1:n);
Z=Ab(:,end);

X = zeros(n,1)
for(i = 1:100)
    licznik=licznik+1
    X1=X;
    X=w*X+Z;
    blad = max(abs(X1-X));
    if(blad<=e)
        break;
    end
end
end

