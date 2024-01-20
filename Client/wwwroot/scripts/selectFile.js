function readFileInfo(inputElement) {
    if (inputElement.files.length === 0) {
        return null;
    }
    const file = inputElement.files[0];
    // Resetowanie inputElement.files po przeczytaniu informacji o pliku
    inputElement.value = '';
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
            return;
        }
        const file = inputElement.files[0];
        const reader = new FileReader();
        reader.onload = () => {
            resolve(reader.result);
            // Dodatkowe wyczyszczenie inputElement.files po wczytaniu
            inputElement.value = '';
        };
        reader.onerror = reject;
        reader.readAsText(file);
    });
}