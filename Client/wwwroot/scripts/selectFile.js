function readFileInfo(inputElement) {
    try {
        if (inputElement.files.length === 0) {
            console.log("No file selected");
            return null;
        }

        const file = inputElement.files[0];

        return {
            name: file.name,
            size: file.size,
            type: file.type,
            lastModified: file.lastModified
        };
    } catch (error) {
        console.error("Error in readFileInfo:", error);
        throw error;
    }
}

function readFileAsText(inputElement) {
    return new Promise((resolve, reject) => {
        try {
            console.log("Number of files selected:", inputElement.files.length);

            if (inputElement.files.length === 0) {
                console.log("No file selected");
                reject("No file selected");
                return;
            }

            const file = inputElement.files[0];

            if (file.size === 0) {
                console.log("Selected file is empty");
                reject("Selected file is empty");
                return;
            }

            const reader = new FileReader();

            reader.onload = () => {
                resolve(reader.result);
            };

            reader.onerror = () => {
                reject("Error reading the file");
            };

            reader.readAsText(file, 'UTF-8');
        } catch (error) {
            console.error("Error in readFileAsText:", error);
            reject(error);
        } finally {
        }
    });
}



