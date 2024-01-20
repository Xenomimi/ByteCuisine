function readFileInfo(inputElement) {
    if (inputElement.files.length === 0) {
        return null;
    }
    const file = inputElement.files[0];
    return {
        name: file.name,
        size: file.size,
        type: file.type,
        lastModified: file.lastModified
    };
}

function readFileAsText(inputElement) {
    return new Promise((resolve, reject) => {
        if (inputElement.files.length === 0) {
            reject("No file selected");
        }
        const file = inputElement.files[0];
        const reader = new FileReader();
        reader.onload = () => resolve(reader.result);
        reader.onerror = reject;
        reader.readAsText(file);
    });
}