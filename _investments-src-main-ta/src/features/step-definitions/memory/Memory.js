/**
 * Class representing Memory
 * @type {Memory}
 */
class Memory {

    /**
     * Bind value to memory class
     * @param {string} key - key
     * @param {string} value - value
     * @example Memory.setValue("key", 1)
     */
    static async setValue(key, value) {
        const session = await browser.getSession();
        const sessionKey = `${session['id_']}_${key}`;
        if (!this.memory) {
            this.memory = {};
        }

        this.memory[sessionKey] = value;

        return this.memory[sessionKey];
    }

    /**
     * Returns value if exists in memory
     * @param {string} key - key
     * @return {string|number|Object} - parsed value
     * @throws {Error}
     * @example Memory.parseValue("$key")
     */
    static parseValue(key) {
        if (typeof key !== "object") {
            const MEMORY_REGEXP = /^(\$|!{1,2})?([^$!]?.+)$/;
            if (key === "") {
                return "";
            }
            const [_, prefix, parsedKey] = key.match(MEMORY_REGEXP);

            switch (prefix) {
                case "$": return this._getMemoryValue(parsedKey);
                case undefined: return parsedKey;
                default: throw new Error(`${parsedKey} is not defined`);
            }
        } else {
            return key;
        }

    }

    /**
     * Return value from memory
     * @param {string} alias - key
     * @return {string|number|Object} - value by key
     * @private
     */
    static async _getMemoryValue(alias) {
        const session = await browser.getSession();
        const sessionAlias = `${session['id_']}_${alias}`;

        if (this.memory[sessionAlias] !== undefined) {
            return this.memory[sessionAlias];
        } else {
            throw new Error(`Value ${alias} doesn't exist in memory`);
        }
    }

}

module.exports = Memory;