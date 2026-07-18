cmake_minimum_required(VERSION 3.15)
project(MyProject)

set(CMAKE_CXX_STANDARD 17)

# -g is a GCC/MinGW option that embeds debugging symbols into the compiled .exe
set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -g")

# Add executables for each file with its own main
add_executable(main ./medium/001-remove-k-digits.cpp)

# Register .hpp utility directly to the executables
target_include_directories(main PUBLIC ./utils)
