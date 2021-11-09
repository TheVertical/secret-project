start-process -filepath "powershell.exe" -WindowStyle minimized -argumentlist  @("-Command", "npm run less-watch");
powershell -WindowStyle minimized -Command "npm run watch";