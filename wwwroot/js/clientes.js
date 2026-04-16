document.addEventListener("DOMContentLoaded", function () {
    cargarClientes();
});

async function guardarCliente() {
    const cliente = {
        cedula: document.getElementById("cedula").value.trim(),
        nombre: document.getElementById("nombre").value.trim(),
        apellido1: document.getElementById("apellido1").value.trim(),
        apellido2: document.getElementById("apellido2").value.trim()
    };

    if (!cliente.cedula || !cliente.nombre || !cliente.apellido1 || !cliente.apellido2) {
        alert("Complete todos los campos");
        return;
    }

    try {
        const response = await fetch("/ClientesPage/Insertar", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(cliente)
        });

        if (!response.ok) {
            const errorText = await response.text();
            console.error("Error al guardar:", errorText);
            alert("Error al guardar cliente");
            return;
        }

        document.getElementById("cedula").value = "";
        document.getElementById("nombre").value = "";
        document.getElementById("apellido1").value = "";
        document.getElementById("apellido2").value = "";

        cargarClientes();
        alert("Cliente guardado correctamente");
    } catch (error) {
        console.error(error);
        alert("Error al guardar");
    }
}

async function cargarClientes() {
    try {
        const response = await fetch("/ClientesPage/ObtenerTodos");

        if (!response.ok) {
            const errorText = await response.text();
            console.error("Error al cargar:", errorText);
            alert("Error al cargar clientes");
            return;
        }

        const clientes = await response.json();
        const tbody = document.querySelector("#tablaClientes tbody");
        tbody.innerHTML = "";

        clientes.forEach(c => {
            const fila = `
                <tr>
                    <td>${c.cedula}</td>
                    <td>${c.nombre}</td>
                    <td>${c.apellido1}</td>
                    <td>${c.apellido2}</td>
                </tr>
            `;
            tbody.innerHTML += fila;
        });
    } catch (error) {
        console.error(error);
        alert("Error al cargar clientes");
    }
}