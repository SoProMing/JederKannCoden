from IPython.display import Markdown, display
import subprocess
from datetime import datetime

def get_git_info():
    try:
        # Aktuellen Commit-Hash
        commit_hash = subprocess.check_output(["git", "rev-parse", "HEAD"]).strip().decode('utf-8')
        # Aktueller Branch
        branch_name = subprocess.check_output(["git", "rev-parse", "--abbrev-ref", "HEAD"]).strip().decode('utf-8')
        return commit_hash[:7], branch_name
    except Exception as e:
        return "Unknown", "Unknown"
    
def get_days_since():
    # Festgelegtes Datum (Projektstart)
    start_date = datetime(2023, 1, 30)
    # Aktuelles Datum
    current_date = datetime.now()
    # Differenz in Tagen berechnen
    return (current_date - start_date).days

def display_document_info():
    commit, branch = get_git_info()
    current_date = datetime.now().strftime("%Y-%m-%d")
    version = "1.0"  # Feste Version oder aus einer Konfigurationsdatei laden
    
    display(Markdown(f"""
    # Dokumentversion und Repository-Status
    - **Version**: {version}.{get_days_since()}
    - **Aktuelles Datum**: {current_date}  
    - **Git-Branch**: {branch}  
    - **Git-Commit**: {commit}  
    """))

# Informationen anzeigen
display_document_info()