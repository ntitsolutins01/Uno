var vm = new Vue({
    el: "#vGenre",
    data: {
        loading: false,
        updateDto: { Id: "", Name: "" }
    },
    mounted: function () {
        var self = this;
        (function ($) {

            if ($.isFunction($.fn['tooltip'])) {
                $('[data-toggle=tooltip],[rel=tooltip]').tooltip({ container: 'body' });
            }

            var formid = $('form')[1].id;

            if (formid === "formUpdateGenre") {

                $("#formUpdateGenre").validate({
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

            if (formid === "formCreateGenre") {

                $("#formCreateGenre").validate({
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
        DeleteGenre: function (id) {
            var url = "../Genre/Delete/" + id;
            $("#deleteGenreHref").prop("href", url);
        },
        UpdateGenre: function (id) {
            var self = this;

            axios.get("../Genre/GetGenreById/?id=" + id).then(result => {

                self.updateDto.Id = result.data.id;
                self.updateDto.Name = result.data.name;

            }).catch(error => {
                Site.Notification("Error fetching and parsing data", error.message, "error", 1);
            });
        }
    }
});

var crud = {
    DeleteModal: function (id) {
        $('input[name="GenreId"]').attr('value', id);
        $('#mdDeleteGenre').modal('show');
        vm.DeleteGenre(id)
    },
    UpdateModal: function (id) {
        $('input[name="GenreId"]').attr('value', id);
        $('#mdUpdateGenre').modal('show');
        vm.UpdateGenre(id)
    }
};