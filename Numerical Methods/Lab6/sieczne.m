function [x_s, n_s, czas_s] = sieczne(f, a, b, ftol,tol)
tic;
 
  n_s = 0;
   while abs(f(b)) > ftol && abs(b - a) > tol
         x_s = b - f(b) * (b - a) / (f(b) - f(a));
       if abs(f(x_s)) <= ftol && abs(x_s - a) <= tol
            break;
        end
        if f(b) - f(a) == 0
            error('Nie można zastosować metody przez dzielenie przez 0');            
        end
        a = b;
        b = x_s;
        n_s = n_s + 1;        
   end
   czas_s=toc;
end