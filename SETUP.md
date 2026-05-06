# Setup

## TypeScript

```ts
npm install -g ts-node typescript '@types/node'

tsc --init

ts-node typescript-file.ts
```

## C#

-   go to `src/learn-topic-wise/<any dsa topic>.csproj`
-   change file name of `<Compile Include="./<file name>.cs" />`

## C++

-   install `cmake`
-   install `MSYS2` - [Refer Here Important](https://code.visualstudio.com/docs/cpp/config-mingw#_prerequisites)
-   run MSYS2 which opens the shell
-   run `pacman -S --needed base-devel mingw-w64-ucrt-x86_64-toolchain`
    -   press Enter
    -   press Y
-   run `pacman -S mingw-w64-ucrt-x86_64-clang-tools-extra`
    -   press Y
-   add `C:\msys64\ucrt64\bin` to `User varaible -> PATH` in `enviornment variables`

### Configure Entry Point

-   open `CMakeLists.txt`
-   change `add_executable(main <file name>.cpp)`

## python

-   global terminal
    -   install pyenv
        -   [pyenv win docs](https://github.com/pyenv-win/pyenv-win)
            -   run in the download folder as it downloads a file - `Invoke-WebRequest -UseBasicParsing -Uri "https://raw.githubusercontent.com/pyenv-win/pyenv-win/master/pyenv-win/install-pyenv-win.ps1" -OutFile "./install-pyenv-win.ps1"; &"./install-pyenv-win.ps1"`
    -   install and set global python version
    -   install `pipx` for the global python version
        -   `python -m pip install --user pipx`
    -   add pipx to `User varaible PATH` in `enviornment variables`
        -   `C:\Users\<user-name>\AppData\Roaming\Python\Python310\Scripts`
    -   run `pipx ensurepath`
    -   install `poetry`
        -   `pipx install poetry`
-   inside the repository
    -   run `poetry install --no-root`

### Reset VENV

- poetry env list
- poetry env remove `<env name>`

**Note:**
virtual env location - C:\Users\<user-name>\AppData\Local\pypoetry\Cache\virtualenvs
