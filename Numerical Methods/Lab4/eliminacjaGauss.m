function x = eliminacjaGauss(A, b)
    n = size(A, 1);
    x = zeros(n, 1);
    
    
    for k = 1:n-1
        for i = k+1:n
            if A(i, k) ~= 0
                lambda = A(i, k) / A(k, k);
                A(i, k+1:n) = A(i, k+1:n) - lambda * A(k, k+1:n);
                b(i) = b(i) - lambda * b(k);
            end
        end
    end
   
    for i = n:-1:1
        x(i) = (b(i) - A(i, i+1:n) * x(i+1:n)) / A(i, i);
    end
end
