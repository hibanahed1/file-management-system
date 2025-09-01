import React, { useEffect, useState } from "react";
import {
  getFiles,
  uploadFile,
  downloadFile,
  deleteFile,
} from "../api/fileService";

interface FileItem {
  id: string;
  fileName: string;
  size: number;
  createdAt: string;
}

const Files: React.FC = () => {
  const [files, setFiles] = useState<FileItem[]>([]);
  const [duplicateFileError, setDuplicateFileError] = useState<string | null>(
    null
  );

  useEffect(() => {
    fetchFiles();
  }, []);

  const fetchFiles = async () => {
    const data = await getFiles();
    setFiles(data);
  };

  const handleFileChange = async (e: React.ChangeEvent<HTMLInputElement>) => {
    if (e.target.files) {
      const file = e.target.files[0];
      const isDuplicate = files.some((f) => f.fileName === file.name);

      if (isDuplicate) {
        setDuplicateFileError("⚠️ This file already exists!");
      } else {
        setDuplicateFileError(null);
        await uploadFile(file);
        await fetchFiles();
      }

      // Clear input so user can re-upload same file if needed
      e.target.value = "";
    }
  };

  const handleDownload = (id: string, fileName: string) => {
    downloadFile(id, fileName).catch((err) =>
      console.error("Download Error:", err)
    );
  };

  const handleDelete = async (id: string) => {
    await deleteFile(id);
    await fetchFiles();
  };

  return (
    <div className="container py-4">
      <h2 className="mb-4 text-primary">
        <i className="bi bi-folder me-2"></i> File Management
      </h2>

      {/* File Upload Section */}
      <div className="card shadow-sm mb-4">
        <div className="card-body">
          <label className="form-label fw-bold" htmlFor="fileUpload">
            <i className="bi bi-upload me-2"></i>Upload a file
          </label>
          <input
            type="file"
            id="fileUpload"
            className="form-control mb-2"
            onChange={handleFileChange}
          />

          {duplicateFileError && (
            <div className="alert alert-warning mt-2">{duplicateFileError}</div>
          )}
        </div>
      </div>

      {/* Files Table */}
      <div className="card shadow-sm">
        <div className="card-header bg-light fw-bold">
          <i className="bi bi-paperclip me-2"></i>Attached Files
        </div>
        <div className="card-body p-0">
          <table className="table table-striped table-bordered">
            
            <thead>
              
              <tr>
                
                <th>File Name</th> <th>Size</th> <th>Created At</th>
                <th>Actions</th>
              </tr>
            </thead>
            <tbody>
              
              {files.map((file) => (
                <tr key={file.id}>
                  
                  <td title={file.fileName}>

                    <span
                      style={{
                        display: "inline-block",
                        maxWidth: "100px",
                        overflow: "hidden",
                        textOverflow: "ellipsis",
                        whiteSpace: "nowrap",
                      }}
                    >
                      
                      <i className="bi bi-paperclip text-success me-1"></i>
                      {file.fileName}
                    </span>
                  </td>
                  <td>
                    <span>{file.size} bytes</span>
                  </td>
                  <td>
                    <span>{new Date(file.createdAt).toLocaleString()}</span>
                  </td>
                  <td>
                    
                    <div
                      className="d-flex align-items-center"
                      style={{ gap: "1rem" }}
                    >
                    
                      <button
                        type="button"
                        className="btn btn-sm btn-outline-secondary"
                        onClick={() => handleDownload(file.id, file.fileName)}
                      >
                        
                        <i className="bi bi-download"></i>
                      </button>
                      <button
                        type="button"
                        className="btn btn-sm btn-outline-danger"
                        onClick={() => handleDelete(file.id)}
                      >
  
                        <i className="bi bi-trash"></i>
                      </button>
                    </div>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>
    </div>
  );
};

export default Files;
