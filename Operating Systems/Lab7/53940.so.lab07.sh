#!/bin/bash
# SO IS1 224A LAB07
# Igor Bębenek 
# bi53940@zut.edu.pl

# Funkcja do modulow ladowalnych (-l)
list_loadable_modules() {
    for FILE in /sys/module/*/
    do
        if [ -e "$FILE/refcnt" ]; then
            MODULE_NAME=$(basename "$FILE")
            REFCNT=$(cat "$FILE/refcnt")
            # Zbieranie nazw modułów 
            HOLDERS=""
            if [ -d "$FILE/holders" ]; then
                HOLDERS=$(ls -1 "$FILE/holders" | tr '\n' ',' | sed 's/,$//')
                #HOLDERS=$(ls "$FILE/holders")
            fi

            printf "%s\t%s\t%s\n" "$MODULE_NAME" "$REFCNT" "$HOLDERS"
        fi
    done | sort
}

# Funkcja do modulow wbudowanych (-b)
list_builtin_modules() {
    for FILE in /sys/module/*/
    do
        if [ ! -e "$FILE/refcnt" ]; then
            MODULE_NAME=$(basename "$FILE")

            # Zbieranie nazw parametrów modułu
            PARAMETERS=""
            if [ -d "$FILE/parameters" ]; then
                PARAMETERS=$(ls -x "$FILE/parameters" | tr '\n' ',' | sed 's/,$//')
            fi

            printf "%s\t%s\n" "$MODULE_NAME" "$PARAMETERS"
        fi
    done | sort
}

# Główna logika skryptu
if [ -z $1 ]; then
    echo "błąd: brak argumentu"
elif [ $1 = -l ]; then
    list_loadable_modules
elif [ $1 = -b ]; then
    list_builtin_modules
else
    echo "błąd: nieprawidłowy argument, spróbuj -l lub -b"
fi