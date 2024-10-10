
// Funcionalidad DataTable de Propietarios
$(document).ready(function() {
    $('#tabla').DataTable({
        language: {
            "sProcessing":   "Procesando...",
            "sLengthMenu":   "Mostrar _MENU_ entradas",
            "sZeroRecords":  "No se encontraron resultados",
            "sInfo":         "Mostrando entradas del _START_ al _END_ de un total de _TOTAL_ entradas",
            "sInfoEmpty":    "Mostrando entradas del 0 al 0 de un total de 0 entradas",
            "sInfoFiltered": "(filtrado de un total de _MAX_ entradas)",
            "sSearch":       "Búsqueda:",
            "sUrl":          "",
            "oPaginate": {
                "sFirst":    "Primero",
                "sPrevious": "Anterior",
                "sNext":     "Siguiente",
                "sLast":     "Último"
            }
    }
    });
});