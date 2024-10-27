import {baseUrl} from "@/environment/environment";

export async function get(route: string) {
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

export async function post(route: string, body: any) {
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

export async function put(route: string, body: any) {
    const request = new Request(`${baseUrl}/${route}`, {
        method: "PUT",
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
