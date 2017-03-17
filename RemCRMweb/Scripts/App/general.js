$(document).ready(function () {
    
    $('li#item').each(function () {                                                                 
        if (this.getElementsByTagName("a")[0].href === location.href) this.className = "active";       //menu.item activ if href==item.href
    });

    $('li#item').click(function () {
        $(".active").removeClass("active");
        $(this).addClass("active");
    });

    var arr = ["Cashboxs", "Orders", "Settings"];
    arr.forEach(function (item, i, arr) {
        $("#" + item).click(function () {
            Content.loadPartial(item);
        });
    });

    $("#addBtn").click(function () {
        Content.openWindowRight();
    });

    $('#content').on('click', "#addBtn", function () {
        Content.openWindowRight();
    });

    $(document).mouseup(function (e) {
        Content.closeWindowRight(e);
    });
    //----------------------for_checkbox_context------------------//
    
    $('body').on('click', '.contextCheckbox', function () {
        
        var stat = $(this).prop('checked'),
            field = $(this).attr('data-field'),
            index = $(this).attr('data-index');

        if (stat) {
            $("#grid").showCol(field);
            if (localStorage.getItem(index) !== null) {
                localStorage.clear;
                localStorage.setItem(index, 'true');
            }
            else localStorage.setItem(index, 'true');
        }
        else {
            $("#grid").hideCol(field);
            if (localStorage.getItem(index) !== null) {
                localStorage.clear;
                localStorage.setItem(index, 'false');
            }
            else localStorage.setItem(index, 'false');
        }
    });
    
    for (var i = 1; i < 19; i++) {
        if (localStorage.getItem(i) === null) localStorage.setItem(i, 'true');
    }
    //----------------------grid_checkbox------------------------------------//
    $('#content').on('click', 'tr', function () {
        var sum_ar_sel = 0;
        $('tr').each(function (i) {

            if ($(this).attr('aria-selected') === 'true' && $(this).hasClass('ui-state-highlight')) {
                $('#operation').removeClass('close');
                sum_ar_sel = 1;
            }
        });
        if (sum_ar_sel === 0) $('#operation').addClass('close');
    });

    //----------------------------------------------------------//

    $('body').click(function (event) {
        console.log(event.target);
    });
    $('body').contextmenu(function (event) {
        console.log(event.target);
    });

    Content.loadGrid();

    $('body').click(function (event) {
        if (event.target.className !== 'contextCheckbox') $('.context-menu').remove();
    });

    Content.contextmenu();

    $("#delBtn").click(function () {
        var number = jQuery("#grid").jqGrid('getGridParam', 'selrow');
        if (number) {
            var ret = jQuery("#grid").jqGrid('getRowData', number);
            
            Order.deleteOrder(ret.Number);
            $("#grid").trigger("reloadGrid", { fromServer: true, page: 1 });
        } else { alert("Please select row"); }
    });

    

});

Content = {
    loadPartial: function (item) {
        history.pushState(null, document.title, item);
        $.ajax({
            url: '/App/' + item,
            cache: false,
            beforeSend: function () { $('#content').html('Please wait...'); },
            success: function (html) {
                $('#content').html(html);
                Content.loadGrid();
            }
        });
    },

    openWindowRight: function () {
        $.ajax({
            type: 'GET',
            url: '/App/AddOrder',
            async: true,
            success: function (html) {
                $('#order').html(html).show('slide', { direction: 'right' }, 500);
                $('#fond').show('fade', 500);
            },
            error: function () { }
        });
    },

    closeWindowRight: function (e) {
        var container = $("#order");
        if (container.has(e.target).length === 0) {
            container.hide('slide', { direction: 'right' }, 500);
            $('#fond').hide('fade', 500);
        }
    },

    loadGrid: function () {
        $("#grid").jqGrid({
            url: '/App/GetData',
            datatype: "json",
            colNames: ['Номер', 'Статус', 'Тип', 'Крайний срок', 'Ориентировачная цена', 'Аванс', 'Срочно',
                       'Фамилия', 'Имя', 'Отчество', 'Телефонный номер', 'Адрес', 'E-mail',
                       'Тип', 'Производитель', 'Модель', 'Серийный номер', 'Дефект'],
            colModel: [
            { name: 'Number', index: 'Number' },
            { name: 'Status', index: 'Status' },
            { name: 'Type', index: 'Type' },
            { name: 'Deadline', index: 'Deadline' },
            { name: 'PriceWill', index: 'PriceWill' },
            { name: 'Prepayment', index: 'Prepayment' },
            { name: 'Quickly', index: 'Quickly' },
            { name: 'Client.Surname', index: 'Client.Surname' },
            { name: 'Client.Name', index: 'Client.Name' },
            { name: 'Client.Middlename', index: 'Client.Middlename' },
            { name: 'Client.TelNumber', index: 'Client.TelNumber' },
            { name: 'Client.Address', index: 'Client.Address' },
            { name: 'Client.Email', index: 'Client.Email' },
            { name: 'Device.Type', index: 'Device.Type' },
            { name: 'Device.Brand', index: 'Device.Brand' },
            { name: 'Device.Model', index: 'Device.Model' },
            { name: 'Device.SerialNumber', index: 'Device.SerialNumber' },
            { name: 'Device.Defect', index: 'Device.Defect' }
            ],
            rowNum: 5,
            loadonce: false,
            sortname: 'Id',
            sortorder: "desc",
            caption: "Заказы",
            pager: '#gridFooter',
            viewrecords: true,
            autowidth: true,
            sortable: true,
            guiStyle: "bootstrap",
            multiboxonly: true,
            multiselect: true,
            //editurl: "/App/DeleteOrder",
            ondblClickRow: function (Number) { Order.editOrder(Number) }
        
        }).navGrid("#gridFooter", { edit: false, add: false, del: false });
        var col = ['Number', 'Status', 'Type', 'Deadline', 'PriceWill', 'Prepayment', 'Quickly',
                   'Client.Surname', 'Client.Name', 'Client.Middlename', 'Client.TelNumber', 'Client.Address', 'Client.Email',
                   'Device.Type', 'Device.Brand', 'Device.Model', 'Device.SerialNumber', 'Device.Defect'];
        for (var i = 1; i < 19; i++) {
            if (localStorage.getItem(i) === 'false') $("#grid").hideCol(col[i - 1]);
        }
        $("#grid").jqGrid('setGroupHeaders', {
            useColSpanStyle: true,
            groupHeaders: [
              { startColumnName: 'Client.Surname', numberOfColumns: 6, titleText: 'Клиент' },
              { startColumnName: 'Device.Type', numberOfColumns: 5, titleText: 'Девайс' }]
        });
    },

    contextmenu: function(){
        $("#content").on('contextmenu', '#gbox_grid', function (event) {
            event.preventDefault();

            $('.context-menu').remove();

                $('<div/>', {
                    class: 'context-menu'
                }).css({ left: event.pageX + 'px', top: event.pageY + 'px' })
                            .appendTo('body').append($('<ul/>')
                            .append('<li><span><input type="checkbox" class="contextCheckbox" class="contextCheckbox" data-field="Number" data-index="1">Номер</span></li>')
                            .append('<li><span><input type="checkbox" class="contextCheckbox" dataeckbox" data-field="Status" data-index="2">Статус</span></li>')
                            .append('<li><span><input type="checkbox" class="contextCheckbox" data-field="Type" data-index="3">Тип</span></li>')
                            .append('<li><span><input type="checkbox" class="contextCheckbox" data-field="Deadline" data-index="4">Крайний срок</span></li>')
                            .append('<li><span><input type="checkbox" class="contextCheckbox" data-field="PriceWill" data-index="5">Предположительная цена</span></li>')
                            .append('<li><span><input type="checkbox" class="contextCheckbox" data-field="Prepayment" data-index="6">Аванс</span></li>')
                            .append('<li><span><input type="checkbox" class="contextCheckbox" data-field="Quickly" data-index="7">Срочно</span></li>')
                            .append('<li><span><input type="checkbox" class="contextCheckbox" data-field="Client.Surname" data-index="8">Фамилия</span></li>')
                            .append('<li><span><input type="checkbox" class="contextCheckbox" data-field="Client.Name" data-index="9">Имя</span></li>')
                            .append('<li><span><input type="checkbox" class="contextCheckbox" data-field="Client.Middlename" data-index="10">Отчество</span></li>')
                            .append('<li><span><input type="checkbox" class="contextCheckbox" data-field="Client.TelNumber" data-index="11">Номер телефона</span></li>')
                            .append('<li><span><input type="checkbox" class="contextCheckbox" data-field="Client.Address" data-index="12">Адрес</span></li>')
                            .append('<li><span><input type="checkbox" class="contextCheckbox" data-field="Client.Email" data-index="13">E-mail</span></li>')
                            .append('<li><span><input type="checkbox" class="contextCheckbox" data-field="Device.Type" data-index="14">Тип</span></li>')
                            .append('<li><span><input type="checkbox" class="contextCheckbox" data-field="Device.Brand" data-index="15">Производитель</span></li>')
                            .append('<li><span><input type="checkbox" class="contextCheckbox" data-field="Device.Model" data-index="16">Модель</span></li>')
                            .append('<li><span><input type="checkbox" class="contextCheckbox" data-field="Device.SerialNumber" data-index="17">Серийный номер</span></li>')
                            .append('<li><span><input type="checkbox" class="contextCheckbox" data-field="Device.Defect" data-index="18">Поломка</span></li>'))
                            .show('fast');
            
                var checks = document.getElementsByClassName("contextCheckbox");                            //получение установленных ранее чекбоксов
                                                                                                            //из локального хранилища
                for (var i = 0; i < checks.length; i++) {                                                   //
                                                                                                            //
                    if (localStorage.getItem($(checks[i]).attr('data-index')) === "true") {                 //
                        $(checks[i]).attr('checked', 'checked');                                            //
                        $("#grid").showCol($(checks[i]).attr('data-field'));                                //
                    }                                                                                       //
                    else if (localStorage.getItem($(checks[i]).attr('data-index')) !== null) $("#grid").hideCol($(checks[i]).attr('data-field'));
                }
        });
    }
}

Order = {

    addOrder: function () {

    },

    editOrder: function (number) {
        $.ajax({
            type: 'GET',
            url: '/App/EditOrder',
            async: true,
            data: { number: number },
            success: function (html) {
                var tabs = "<ul><li><a href=#tabs-1>Информация о заказе</a></li>" +
                           "<li><a href=#tabs-2>Работы и материалы</a></li></ul>" +
                           "<div id=tabs-1></div>" +
                           "<div id=tabs-2><p>Содержимое второй вкладки</p></div>";
                $('#order').html(tabs);
                $('#tabs-1').html(html);

                $("#order").tabs({

                    ajaxOptions: {
                        error: function (xhr, status, index, anchor) {
                            $(anchor.hash).html("Содержимое не найдено :(");
                        }
                    }
                });

                $('#order').show('slide', { direction: 'right' }, 500);
                $('#fond').show('fade', 500);
                
                
                
            },
            error: function() {}
        });
        
    },

    deleteOrder: function (number) {
        
        $.ajax({
            type: 'GET',
            url: '/App/DeleteOrder',
            async: true,
            data: {numberOrder: number},
            success: {},
            error:{}
        });
    }
}

