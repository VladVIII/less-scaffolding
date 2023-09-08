const { route } = require('@chuva.io/less');
const controller = require('controllers/datasets');

module.exports = {
    get: route(async (req, res) => {
        return await controller.get_by_id(req, res);
    }, [])
}
