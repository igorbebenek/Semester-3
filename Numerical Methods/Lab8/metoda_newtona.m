function metoda_newtona
    % Definicja funkcji
   % f = @(x) (1/3)*x.^2 - (13/7)*x + 11;
     f = @(x) x.^4 - 12*x.^3 + x + 4;
   % xk = -10; 
    xk= 0;
    tol = 1e-5;
    h = 0.001;
    
    tic;

    iter = 0;
    iteracje = [];
    wartosci_funkcji = [];

    while abs(f_prime(f, xk, h)) > tol
        iter = iter + 1;
        dfk = f_prime(f, xk, h);
        ddfk = f_double_prime(f, xk, h);

        xk = xk - dfk / ddfk;

        iteracje(end+1) = iter;
        wartosci_funkcji(end+1) = f(xk);

        if iter > 1 && abs(xk - iteracje(end-1)) <= tol
            break;
        end
    end

    czas = toc;

    fprintf('Znalezione minimum: %f\n', xk);
    fprintf('Liczba iteracji: %d\n', iter);
    fprintf('Czas: %f sekund\n', czas);

    figure;
    fplot(f, [-10 10]);
    hold on;
    plot(xk, f(xk), 'r*');
    title('Funkcja i znalezione minimum');
    xlabel('x');
    ylabel('f(x)');

    figure;
    plot(iteracje, wartosci_funkcji, '-o');
    title('Wartości funkcji w kolejnych iteracjach');
    xlabel('Iteracja');
    ylabel('f(x)');
end
