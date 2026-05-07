namespace PyBro {
    public interface IFileManager {
        
        /// <summary>
        /// Creates an empty file  
        /// </summary>
        /// <param name="path">Path of the file to be created</param>
        //  TODO: alege ce exceptii sa arunce metodele din fisierul asta si termina de comentat fisierul. nu uita sa stergi comentariul /// <exception cref="ArgumentNullException"> 
        /// Thrown when name is null.
        /// </exception>
        public void CreateFile(String path);

        /// <summary>
        /// Creates a file with contents of a buffer.   
        /// </summary>
        /// <param name="path">Path of the file to be created</param>
        /// <param name="buffer">Content of the file</param>
        public void CreateFile(String path, IBuffer buffer);
        
        /// <summary>
        /// Creates an empty file  
        /// </summary>
        /// <param name="path">Path of the file to be created</param>
        public void RemoveFile(String path);
        
        /// <summary>
        /// Creates an empty file  
        /// </summary>
        /// <param name="path">Path of the file to be created</param>
        public void SaveFile();

        /// <summary>
        /// Creates an empty file  
        /// </summary>
        /// <param name="path">Path of the file to be created</param>
        public string LoadFile();
    }
}