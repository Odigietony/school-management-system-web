$(document).ready(function () {
    $('.custom-file-input').on("change", function () {
        var fileName = $(this).val().split("\\").pop();
        $(this).next('.custom-file-label').html(fileName);
    });
}); 


function editUser(id)
{ 
    let url = '/UserRoles/EditRoles/';
    let $modal = $("#editDetailModal");
    $modal.find('.modal-body').load(url + id, function(){
        $modal.modal('show');
    });
} 

function editUserRole(roleId)
{
    let url1 = '/UserRoles/UpdateUserRole/'; 
    let $modal1 = $("#editUserRole");
    $modal1.find('.modal-body').load(url1 + roleId, function(){
        $modal1.modal('show');
    });
}

function updateUserData()
{
    let id = $('#userRoleId').val();
    let rolename = $('#userRoleName').val();  
    let url = '/UserRoles/EditRoles/';
    let modelData = ({'Id': id, 'RoleName': rolename}); 
    
    
    $.ajax({
        type: 'POST',
        url: url,
        data:  modelData, 
        success: function(result)
        {
            if(result.success == true)
            {  
                setTimeout(function(){
                    location.reload(); 
                }, 200);
            }
            else
            {
                $('#editForm').html(result); 
            }
        }
    });
} 



function updateUserRoleData()
{
    let id = $('#roleId').val();  
    let url = '/UserRoles/UpdateUserRole/';
    let model = $('#UserRoleForm').serializeArray();
    model.push({name: 'Id', value: id}); 
    $.ajax({
        type: 'POST',
        url: url,
        data: $.param(model), 
        success: function(result)
        {
            if(result.success == true)
            {  
                $('.modal').modal('hide');
                $('#alert').addClass('on');
            }
            else
            {
                $('.modal').modal('hide'); 
            }
        }
    });
}

function ConfirmDelete(uniqueId)
{
    url = "/UserRoles/DeleteRole/" + uniqueId;
    $.ajax({
        type: "POST",
        url: url,
        data: {'Id': uniqueId},
        success: function(result)
        {
            if(result.success == true)
            {
                setTimeout(function(){
                    location.reload(); 
                }, 500);
            }
        }
    });
}

function ConfirmAdminDelete(uniqueId)
{
    url = "/Admin/Delete/" + uniqueId;
    $.ajax({
        type: "POST",
        url: url,
        data: {'Id': uniqueId},
        success: function(result)
        {
            if(result.success == true)
            {
                setTimeout(function(){
                    location.reload(); 
                }, 500);
            }
        }
    });
}

function DeleteData(uniqueId)
{
    url = $('#deleteForm').attr('action'); 
    $.ajax({
        type: "POST",
        url: url + "/"+ uniqueId,
        data: {'Id': uniqueId},
        success: function(result)
        {
            if(result.success == true)
            {
                setTimeout(function(){
                    location.reload();
                }, 500);
            }
        }
    });
}

function GetFacultyDataById(Id)
{
    url = '/faculty/editfacultydata/';
    let $modal = $('#editFacultyData')
    $modal.find('.modal-body').load(url + Id, function(){
        $modal.modal('show');
    }); 
}

function EditData()
{
    let id = $('#facultyId').val();
    url = '/faculty/editfacultydata/';  
    let model = $('#editForm').serializeArray(); 
    model.push({name: 'Id', value: id}); 
     alert($.param(model));
    $.ajax({
        type: "POST",
        url: url,
        data: model,
        success: function(result)
        {
            if(result.success == true)
            {
                setTimeout(function(){
                    location.reload();
                }, 500);
            } 
            else
            {
                $('#editForm').html(result); 
            }
            
        }
    });
}
