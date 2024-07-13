function user_edit(h, ~, u)
    kolor = get(u.edycja, 'String');
   try
        set(u.okno, 'Color', kolor);
    catch
        set(u.okno, 'Color', [1, 1, 1]);
    end

    end