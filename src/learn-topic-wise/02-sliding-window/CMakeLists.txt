cmake_minimum_required(VERSION 3.15)
project(SlidingWindowExamples)

set(CMAKE_CXX_STANDARD 17)

# -g is a GCC/MinGW option that embeds debugging symbols into the compiled .exe
set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -g")

# Add executables for each file with its own main
add_executable(main 022-count-suarrays-where-max-element-appears-at-least-k-times.cpp)
