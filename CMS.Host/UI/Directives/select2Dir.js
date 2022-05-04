angular.module('CMS')
    .directive('select2', ['$parse', function ($parse) {

        function link(scope, element, attrs) {
            scope.$watch(attrs.opts, function (opts) {
                if (opts != null) {
                    if (!_.isArray(opts)) {
                        opts = _.map(opts, function (value, key) {
                            return { id: value, text: key.replace(/_/g, ' ') };
                        });
                    }
                    var multiple = $parse(attrs.multiple)(scope);
                    element.select2({
                        placeholder: multiple ? "Select multiple items..." : "Select an item...",
                        data: opts,
                        multiple: multiple,
                        initSelection: function (element, callback) {
                            var searchTerm = $parse(attrs.ngModel)(scope);
                            if (searchTerm !== "") {
                                scope[onquerycallback].call(callbackScope, attrs.querymethod, attrs.queryurl, searchTerm)
                                    .then(function (result) {
                                        if (result && result.length > 0) {
                                            data.text = [result[0].text];
                                        }
                                        callback(data);
                                    });
                            }
                        }
                    }).on('select2:select', function (e) {
                        if (e.params.data) {
                            scope.$apply(function () {
                                $parse(attrs.ngModel).assign(scope, e.params.data.id);
                            });
                        }
                    });

                    scope.$watch(attrs.ngModel, function (ngModel) {
                        //element.select2("val", ngModel);
                        //element.val(ngModel).trigger('change');
                    });
                }
            });
        }

        return {
            link: link
        };
    }]);