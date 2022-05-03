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
                    element.select2({
                        placeholder: "Select an item...",
                        data: opts
                    }).on('select2:select', function (e) {
                        if (e.params.data) {
                            scope.$apply(function () {
                                $parse(attrs.ngModel).assign(scope, e.params.data.id);
                            });
                        }
                    });
                }
            });
        }

        return {
            link: link
        };
    }]);