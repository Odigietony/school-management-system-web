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
                $('.modal-body').html(result); 
            }
        }
    });
} 



function updateUserRoleData()
{
    let id = $('#userRoleId').val();
    let rolename = $('#userRoleName').val(); 
    let userid = $('#userid').val();
    let username = $('#username').val(); 
    let selected_value = ($('#selectValue').is(':checked')) ? true : false; 
    let url = '/UserRoles/UpdateUserRole/';
    let model = {'model': [{'UserId': userid, 'Username': username, 'IsSelected': selected_value}], 'Id': id};  
    $.ajax({
        type: 'POST',
        url: url,
        data: model, 
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