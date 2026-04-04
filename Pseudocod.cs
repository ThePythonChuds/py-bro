// Editor

implementezi metoda
comentezi metoda
scrii teste

Dependente:
	- IronPython sau Python.NET
  - NUnit sau XUnit pentru teste
  - Moq pentru mocking
	- Winforms, WPF sau web kit
  - python3 instalat pe sistem

// Thread Safe
class MessageQueue<IActionType> {
  void Push(ActionType a);
  IActionType Pop();
}

// Responsabila sa trimita mesaje catre Renderer si Editor prin cozile de mesaje
class Ide {
	  
}

while (1) {
  var actions = actionProvide.ReadActions();
  editor.RegisterActions(actions);
  
  var buffer = editor.GetBuffer();
  
  // aici o sa faca ide-ul comanda de desen
  ui.Render(drawCommand);
}


interface IActionProvider  {
  /* Ctrl+c copy
   * Ctrl+v paste
   * Ctrl+z undo
   * Ctrl+r redo
   * Ctrl+x cut
   * Ctrl+s save
   * Ctrl+l Load file
   * Scroll View
   * 
   * InsertText 
   * RemoveText
   * HighlightText
   * Ctrl+f -> find
   * F11 - Run current file
   * Ctrl+~ open console
   */
  List<Action> ReadActions();
}

// Ruleaza pe thread separat
interface IEditor {
  
  List<String> lines;
  Stack<Action> actions;
  
  List<String> GetBuffer();
	void RegisterActions(List<Action> actions);
  
  void Insert(int line, int pos, String s);

  void Delete(int line, int sctPos, int endPos);

}

struct DrawCommand {
  List<String> textBuffer;
  int firstLine; // Prima linie care trebuie randata
	Pair<int, int> cursorPosition;
  
  Color textColor;
  HashMap<String, Color> specialTextColors;
  // specialTextColors.Get("def")
  
  Color backgroundColor;
  
  int currentFocusedWindow; // Daca esti focusat pe fereastra text sau pe consola
  													// 0 -> fereastra, 1 -> consola
}

// Ruleaza pe thread separat
interface IUi {  
  void Render(DrawCommand rc);
}

class Cursor {
  int line, col;
  Pair<int, int> GetPos();
  void MoveCursor(Pair<int, int> newPos);
  void MoveCol(int mv); // 2 -> +2 coloane la dreapta, -1 -> o coloana mai la stanga
  void MoveLine(int mv); // acelasi lucru ca mai sus
}

enum ConsoleAction {
  ADD_CHAR, // adauga ch
  RM_CHAR, // sterge caracterul de la cursor
  RUN_CMD

  Char ch;
}

interface IConsole {
	
}
  
interface PythonEngine {
  void LoadScript();
  
  /**
   * @throws RunScriptException - daca scriptul crapa
   */
  void RunScript();
  
  /**
   * @throws NotFoundException - daca nu exista variabila name
   */
	object GetVal(String name);
}  

  
  
  ``
  num = 1 + 4
  name = "pula mea"
  ``
  GetVal("name")

class Settings {
  	useSpaceInsteadOfTabs: boolean
  	numberOfSpacesIndent:  int
    
    fontSize: int
    colors: HashMap<Color>
    plugins: Collection<String> // path-ul catre fisierul .py pentru fiecare plugin

    void LoadSettings(); // incarca valorile setarilor din fisierul settings.py in variabilele de mai sus ^
  	void SaveSettings(); // salveaza valorile din ram in settings.py
}
  
class PluginManager {
  void LoadPlugin(String name);
	void AddPlugin(String name);
  void RemovePlugin(String name);
}  
  





