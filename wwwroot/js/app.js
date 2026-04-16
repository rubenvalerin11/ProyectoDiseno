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
        let posicion = -1;

        // Buscar operador (de derecha a izquierda para evitar confusión con signos negativos)
        for (let i = expresion.length - 1; i > 0; i--) {
            if (['+', '-', '*', '/'].includes(expresion[i])) {
                operador = expresion[i];
                posicion = i;
                break;
            }
        }

        if (operador === "" || posicion === -1) {
            mostrarError("Ingrese una operación válida.");
            return;
        }

        const numero1Str = expresion.substring(0, posicion).trim();
        const numero2Str = expresion.substring(posicion + 1).trim();

        const n1 = parseFloat(numero1Str);
        const n2 = parseFloat(numero2Str);

        if (isNaN(n1) || isNaN(n2)) {
            mostrarError("Ingrese números válidos.");
            return;
        }

        // Validación: división entre cero
        if (operador === "/" && n2 === 0) {
            mostrarError("❌ Error: No se puede dividir entre cero.");
            return;
        }

        let resultado = 0;
        let claseColor = "";

        switch (operador) {
            case "+":
                resultado = n1 + n2;
                claseColor = "resultado-suma";
                break;
            case "-":
                resultado = n1 - n2;
                claseColor = "resultado-resta";
                break;
            case "*":
                resultado = n1 * n2;
                claseColor = "resultado-multi";
                break;
            case "/":
                resultado = (n1 / n2) * 1.5;
                claseColor = "resultado-division";
                break;
        }

        // Mostrar resultado con color
        resultadoDiv.className = `resultado-box mt-3 ${claseColor}`;

        if (operador === "/") {
            resultadoDiv.textContent = `Resultado (÷ ×1.5): ${resultado.toFixed(2)}`;
        } else {
            resultadoDiv.textContent = `Resultado: ${resultado.toFixed(2)}`;
        }

        // Guardar en historial
        let operacionTexto = "";
        if (operador === "/") {
            operacionTexto = `${n1} ÷ ${n2} = ${resultado.toFixed(2)} (×1.5)`;
        } else {
            operacionTexto = `${n1} ${operador} ${n2} = ${resultado.toFixed(2)}`;
        }
        historialOperaciones.push(operacionTexto);

        // Guardar en localStorage para persistencia
        localStorage.setItem("historialOperaciones", JSON.stringify(historialOperaciones));

        // Limpiar display después de 2 segundos
        setTimeout(() => {
            display.value = resultado.toFixed(2);
        }, 500);

    } catch (error) {
        mostrarError("❌ Ocurrió un error al calcular: " + error.message);
    }
}

function mostrarError(mensaje) {
    const resultadoDiv = document.getElementById("resultadoColor");
    if (resultadoDiv) {
        resultadoDiv.className = "resultado-box mt-3";
        resultadoDiv.textContent = mensaje;
        resultadoDiv.style.color = "#dc3545";
    }
    alert(mensaje);
}

// Cargar historial del localStorage al iniciar
document.addEventListener("DOMContentLoaded", function() {
    const historialGuardado = localStorage.getItem("historialOperaciones");
    if (historialGuardado) {
        historialOperaciones = JSON.parse(historialGuardado);
    }
});