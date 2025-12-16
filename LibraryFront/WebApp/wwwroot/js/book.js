var vm = new Vue({
    el: "#vBook",
    data: {
        loading: false,
        updateDto: { Id: "", Title: "", Author: "", Description: "", Genre: "" }
    },
    mounted: function () {
        var self = this;
        (function ($) {

            var $select = $(".select2").select2({
                allowClear: true
            });

            $(".select2").each(function () {
                var $this = $(this),
                    opts = {};

                var pluginOptions = $this.data('plugin-options');
                if (pluginOptions)
                    opts = pluginOptions;

                $this.themePluginSelect2(opts);
            });

            /*
             * When you change the value the select via select2, it triggers
             * a 'change' event, but the jquery validation plugin
             * only re-validates on 'blur'*/

            $select.on('change', function () {
                $(this).trigger('blur');
            });

            if ($.isFunction($.fn['tooltip'])) {
                $('[data-toggle=tooltip],[rel=tooltip]').tooltip({ container: 'body' });
            }

            var formid = $('form')[1].id;

            if (formid === "formUpdateBook") {

                $("#formUpdateBook").validate({
                    highlight: function (label) {
                        $(label).closest('.form-group').removeClass('has-success').addClass('has-error');
                    },
                    success: function (label) {
                        $(label).closest('.form-group').removeClass('has-error');
                        label.remove();
                    },
                    errorPlacement: function (error, element) {
                        var placement = element.closest('.input-group');
                        if (!placement.get(0)) {
                            placement = element;
                        }
                        if (error.text() !== '') {
                            placement.after(error);
                        }
                    }
                });
            }

            if (formid === "formCreateBook") {

                $("#formCreateBook").validate({
                    highlight: function (label) {
                        $(label).closest('.form-group').removeClass('has-success').addClass('has-error');
                    },
                    success: function (label) {
                        $(label).closest('.form-group').removeClass('has-error');
                        label.remove();
                    },
                    errorPlacement: function (error, element) {
                        var placement = element.closest('.input-group');
                        if (!placement.get(0)) {
                            placement = element;
                        }
                        if (error.text() !== '') {
                            placement.after(error);
                        }
                    }
                });
            }

        }).apply(this, [jQuery]);
    },
    methods: {
        ShowLoad: function (flag, el) {
            var self = this;

            self.isLoading = flag;
            $("#" + el).loadingOverlay({
                "startShowing": flag
            });
            self.loading = flag;

            if (!flag) {
                self.isLoading = flag;
                $("#" + el).removeClass("loading-overlay-showing");
                self.loading = flag;
            } else {
                self.isLoading = flag;
                $("#" + el).addClass("loading-overlay-showing");
                self.loading = flag;
            }
        },
        DeleteBook: function (id) {
            var url = "../Book/Delete/" + id;
            $("#deleteBookHref").prop("href", url);
        },
        UpdateBook: function (id) {
            var self = this;

            axios.get("../Book/GetBookById/?id=" + id).then(result => {

                self.updateDto.Id = result.data.book.id;
                self.updateDto.Title = result.data.book.title;
                self.updateDto.Author = result.data.book.author;
                self.updateDto.Description = result.data.book.description;
                self.updateDto.Genre = result.data.book.genre;

                if (result.data.listLanguage && result.data.listLanguage.length > 0) {

                    var items = '<option value="">Select Language</option>';

                    $("#ddlLanguageUpdate").empty();

                    $.each(result.data.listLanguage,
                        function (i, row) {
                            if (row.selected) {
                                items += "<option selected value='" + row.value + "'>" + row.text + "</option>";
                            } else {
                                items += "<option value='" + row.value + "'>" + row.text + "</option>";
                            }
                        });

                    $("#ddlLanguageUpdate").html(items);

                } else {
                    new PNotify({
                        title: 'Book',
                        text: 'Genders not found.',
                        type: 'warning'
                    });
                }

            }).catch(error => {
                Site.Notification("Error fetching and parsing data", error.message, "error", 1);
            });
        },
        RentBook: function (id) {
            var url = "../Book/Rent/" + id;
            $("#rentBookHref").prop("href", url);
        }
    }
});

var crud = {
    DeleteModal: function (id) {
        $('input[name="BookId"]').attr('value', id);
        $('#mdDeleteBook').modal('show');
        vm.DeleteBook(id)
    },
    UpdateModal: function (id) {
        $('input[name="BookId"]').attr('value', id);
        $('#mdUpdateBook').modal('show');
        vm.UpdateBook(id)
    },
    RentModal: function (id) {
        $('input[name="BookId"]').attr('value', id);
        $('#mdRentBook').modal('show');
        vm.RentBook(id)
    }
};