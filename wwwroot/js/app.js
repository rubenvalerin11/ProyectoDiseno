let historialOperaciones = [];

function agregarValor(valor) {
    document.getElementById("display").value += valor;
}

function limpiarDisplay() {
    document.getElementById("display").value = "";
    const resultadoDiv = document.getElementById("resultadoColor");
    if (resultadoDiv) {
        resultadoDiv.className = "resultado-box mt-3";
        resultadoDiv.textContent = "";
    }
}

function calcularResultado() {
    const display = document.getElementById("display");
    const resultadoDiv = document.getElementById("resultadoColor");
    const expresion = display.value.trim();

    if (expresion === "") {
        return;
    }

    try {
        let operador = "";

        if (expresion.includes("+")) operador = "+";
        else if (expresion.includes("-")) operador = "-";
        else if (expresion.includes("*")) operador = "*";
        else if (expresion.includes("/")) operador = "/";

        if (operador === "") {
            alert("Ingrese una operación válida.");
            return;
        }

        const partes = expresion.split(operador);

        if (partes.length !== 2) {
            alert("Ingrese una operación válida.");
            return;
        }

        const n1 = parseFloat(partes[0]);
        const n2 = parseFloat(partes[1]);

        if (isNaN(n1) || isNaN(n2)) {
            alert("Ingrese números válidos.");
            return;
        }

        if (operador === "/" && n2 === 0) {
            alert("Error: no se puede dividir entre cero.");
            return;
        }

        let resultado = 0;
        let claseColor = "";

        switch (operador) {
            case "+":
                resultado = (n1 + n2) * 1.5;
                claseColor = "resultado-suma";
                break;
            case "-":
                resultado = (n1 - n2) * 1.5;
                claseColor = "resultado-resta";
                break;
            case "*":
                resultado = (n1 * n2) * 1.5;
                claseColor = "resultado-multi";
                break;
            case "/":
                resultado = (n1 / n2) * 1.5;
                claseColor = "resultado-division";
                break;
        }

        resultadoDiv.className = `resultado-box mt-3 ${claseColor}`;
        resultadoDiv.textContent = `Resultado final x1.5: ${resultado}`;

        const textoHistorial = `${n1} ${operador} ${n2} = ${resultado}`;
        historialOperaciones.push(textoHistorial);

        const lista = document.getElementById("listaHistorial");
        if (lista) {
            lista.innerHTML = "";
            historialOperaciones.forEach(op => {
                const li = document.createElement("li");
                li.className = "list-group-item";
                li.textContent = op;
                lista.appendChild(li);
            });
        }
    } catch {
        alert("Ocurrió un error al calcular.");
    }
} 