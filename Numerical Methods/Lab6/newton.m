function [x_n, n_n, czas_n] = newton(f, a, b, tol, ftol)
  tic
    x_n = (a + b) / 2;  
    n_n = 0; 
   
    while abs(f(x_n)) > ftol && abs(b - a) > tol
        h = 1e-6; 
        df = (f(x_n + h) - f(x_n - h)) / (2 * h);
        x_n = x_n - f(x_n) / df;
        n_n = n_n + 1;
   
    end
    
   czas_n = toc; 
end
