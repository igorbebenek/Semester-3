function [T, Wx] = newton_wielomian(X, Y, arg)
    
    n = length(X);
    T = zeros(n, n);
    T(:,1) = Y'; 

    % Wypełnienie tablicy ilorazów różnicowych
    for j = 2:n
        for i = j:n
            T(i,j) = (T(i,j-1) - T(i-1,j-1)) / (X(i) - X(i-j+1));
        end
    end

    Wx = T(1,1);
    for i = 2:n
        product = T(i, i);
        for j = 1:i-1
            product = product * (arg - X(j));
        end
        Wx = Wx + product;
    end
end
