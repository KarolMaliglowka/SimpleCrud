import {baseUrl} from "@/environment/environment";

export async function getAll(route: string) {
    try {
        const response = await fetch(`${baseUrl}/${route}`, {
            method: 'GET',
            cache: 'no-cache',
            credentials: 'same-origin',
        });
        return response.json();
    } catch (err) {
        console.error(`GET error: ${err}`);
    }
}

export async function create(route: string, body: any) {
    const request = new Request(`${baseUrl}/${route}`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(body),
    });

    try {
        const response = await fetch(request);
        const result = await response.json();
        console.log("Success:", result);
    } catch (error) {
        console.error("Error:", error);
    }
}

export async function update(route: string, body: any) {
    const request = new Request(`${baseUrl}/${route}`, {
        method: "PATCH",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(body),
    });

    try {
        const response = await fetch(request);
        const result = await response.json();
        console.log("Success:", result);
    } catch (error) {
        console.error("Error:", error);
    }
}

export async function remove(route: string, body: any) {
    const request = new Request(`${baseUrl}/${route}/${body.id}`, {
        method: "DELETE",
        headers: {
            "Content-Type": "application/json",
        },
        body: null,
    });

    try {
        const response = await fetch(request);
        const result = await response.json();
        console.log("Success:", result);
    } catch (error) {
        console.error("Error:", error);
    }
}
