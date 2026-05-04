import tomllib
import subprocess
from pathlib import Path

project_file = Path(__file__).parent / "pyproject.toml"

with open(project_file, "rb") as f:
    data = tomllib.load(f)

entry = data["tool"]["my_py_app"]["entry"]
subprocess.run(["python", str(Path(__file__).parent / entry)])