function linear_programming_simplex(A, B, Z, F, Wb)
    if any(B < 0)
        error('Wektor B zawiera wartości ujemne.');
    end

    is_last_table = false;
 while ~is_last_table
        Cb = F(Wb);

        z = 0;
        for i = 1:length(Wb)
            z = z + Cb(i) * B(i);
        end

        WW = zeros(1, length(F));
        for j = 1:length(F)
            if ismember(j, Wb)
                WW(j) = inf; 
            else
                WW(j) = F(j) - sum(Cb' .* A(:, j));
            end
        end
        if all(WW >= 0)
            is_last_table = true;
            disp('To jest ostatnia tablica');
        else
            disp('To nie jest ostatnia tablica');
            [~, key_col] = min(WW);

            ratios = B ./ A(:, key_col);
            ratios(ratios <= 0 | isinf(ratios) | isnan(ratios)) = inf;
            [min_ratio, key_row] = min(ratios);

            if isinf(min_ratio)
                error('Problem nie ma rozwiązania.');
            end

            Wb(key_row) = key_col;

            key_element = A(key_row, key_col);
            A(key_row, :) = A(key_row, :) / key_element;
            B(key_row) = B(key_row) / key_element;
            for i = 1:size(A, 1)
                if i ~= key_row
                    factor = A(i, key_col);
                    A(i, :) = A(i, :) - factor * A(key_row, :);
                    B(i) = B(i) - factor * B(key_row);
                end
            end
        end

        disp(table(B, A));
    end

x = zeros(size(F));
for i = 1:length(Wb)
    x(Wb(i)) = B(i); 
end
max_value = F * x';
disp(['Maksymalna wartość funkcji celu wynosi ', num2str(max_value), ', dla zmiennych: ', num2str(x)]);
end
