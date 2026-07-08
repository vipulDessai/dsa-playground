cmake_minimum_required(VERSION 3.15)
project(SlidingWindowExamples)

set(CMAKE_CXX_STANDARD 17)

# -g is a GCC/MinGW option that embeds debugging symbols into the compiled .exe
set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -g")

# Register utility
add_library(generate-trees
    ./utils/generate-trees.cpp
)
target_include_directories(generate-trees PUBLIC ./utils)

# Add executables for each file with its own main
add_executable(main ./hard/001-serialize-deserialize-tree.cpp)

# Link the executable to the library
target_link_libraries(main PRIVATE generate-trees)
