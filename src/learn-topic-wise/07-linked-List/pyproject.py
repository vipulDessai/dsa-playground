import tomli
import subprocess
from pathlib import Path

project_file = Path(__file__).parent / "pyproject.toml"

with open(project_file, "rb") as f:
    data = tomli.load(f)

entry = data["tool"]["my_py_app"]["entry"]

# Converts "./medium/007-delete-node-in-a-linked-list.py" → "medium.007-delete-node-in-a-linked-list"
module_entry = Path(entry).with_suffix("").as_posix().replace("/", ".")

subprocess.run(["python", "-m", module_entry])
