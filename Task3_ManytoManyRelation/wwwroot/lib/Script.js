$.get("GetEmployeesSkills", function (data, status) {
    let code = "";
    for (let x in data) {
        code += "<tr>"
        code += "<td>" + data[x].employee_id + "</td>"
        code += "<td>" + data[x].employee_name + "</td>"
        code += "<td>" + data[x].status + "</td>"
        code += "<td>" + data[x].manager + "</td>"
        code += "<td>" + data[x].wfm_manager + "</td>"
        code += "<td>" + data[x].email + "</td>"
        code += "<td>"
        for (let y in data[x].skills)
            code += data[x].skills[y] + "  "
        code += "</td></tr>"
    }
    $('#data').html(code)
})