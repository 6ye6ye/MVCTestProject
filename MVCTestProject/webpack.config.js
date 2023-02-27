const HtmlWebpackPlugin = require('html-webpack-plugin');
const { VueLoaderPlugin } = require('vue-loader');
const path = require('path');

module.exports = {
    mode: 'development',
    devtool: 'eval',
    entry: [
        './src/js/app.js',
    ],
    output: {
        clean: true,
        path: path.resolve(__dirname, 'dist'),
        publicPath: '/dist',
        filename: '[name].bundle.[contenthash].js',
    },
    resolve: {
        // point bundler to the vue template compiler
        alias: {
            'vue$': 'vue/dist/vue.esm.js',
        },
        // allow imports to omit file exensions, 
        // e.g. "import foo from 'foobar'" instead of "import foo from 'foobar.js'"
        extensions: ['.js', '.vue'],
    },
    module: {
        rules: [
            // use vue-loader plugin for .vue files
            {
                test: /\.vue$/,
                use: 'vue-loader'
            },
        ],
    },
    plugins: [
        new VueLoaderPlugin(),
        new HtmlWebpackPlugin({
            template: 'src/index.html',
            inject: true,
            // favicon: 'src/images/favicon.ico',
            publicPath: '/dist'
        }),
    ],
};