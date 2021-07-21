const commonConfig = require('./webpack.common.config');
const path = require('path');

module.exports = (env) => {
    const config = commonConfig.getConfig(env);

    config.entry = {
        'secrert-project': './apps/main/main.tsx',
        ...config.entry
    }
    config.output = {
        'path': path.resolve('../SecretProject.WebApi/Scripts/React', 'dist'),
        publicPath: 'auto',
        filename: '[name].bundle.js',
        chunkFilename: '[name].chunkhash.bundle.js',
    };

    return config;
}