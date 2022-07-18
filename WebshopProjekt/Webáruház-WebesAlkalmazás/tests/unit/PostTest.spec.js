import { mount } from '@vue/test-utils'
import Post from '@/views/WebS.vue'

describe('Post tesztelés', () => {
    test('Termékek elhelyezése a kosár tartalmába' , async () =>{
        const wrapper = mount(Post)
        const select = wrapper.find('select[name=megnevezes]')
        await select.setValue('Málnalekváros fánk')
        expect(wrapper.vm.megnevezes).toBe('Málnalekváros fánk')
    })
})