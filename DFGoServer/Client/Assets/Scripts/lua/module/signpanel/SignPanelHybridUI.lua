--Created by HybridUI V3.0
_G.SignPanelHybridUI = class(BaseUI)

UIPanelName.SignPanel = "SignPanel"

function SignPanelHybridUI:ctor()
	self.prefabName = 'SignPanel'
	self.parentNodeName = _G.UILayerConsts.CENTER
end

function SignPanelHybridUI:OnLoaded()
	SignPanelHybridUI.superclass.OnLoaded(self)
	self.Content = UGUIObject.New(self.transform:Find('Content'))
	self.Content.tittleBG = UGUIObject.New(self.transform:Find('Content/tittleBG'))
	self.Content.tittleBG.Text = Text.New(self.transform:Find('Content/tittleBG/Text'))
	self.Content.Text = Text.New(self.transform:Find('Content/Text'))
	self.Content.invitecodeBG = UGUIObject.New(self.transform:Find('Content/invitecodeBG'))
	self.Content.invitecodeBG.Text = Text.New(self.transform:Find('Content/invitecodeBG/Text'))
	self.Content.number = Text.New(self.transform:Find('Content/number'))
	self.Content.inviteNum = UGUIObject.New(self.transform:Find('Content/inviteNum'))
	self.Content.inviteNum.Text = Text.New(self.transform:Find('Content/inviteNum/Text'))
	self.Content.closeBtn = Button.New(self.transform:Find('Content/closeBtn'))
end

function SignPanelHybridUI:IsLoadAsync()
	return true
end

function SignPanelHybridUI:IsNeverDelete()
	return true
end

function SignPanelHybridUI:IsImmediatelyDelete()
	return true
end

function SignPanelHybridUI:IsTween()
	return true
end

function SignPanelHybridUI:IsFullScreen()
	return false
end

function SignPanelHybridUI:IsScreenBlur()
	return false
end

function SignPanelHybridUI:IsPlaySound()
	return true
end

function SignPanelHybridUI:Destroy()
	SignPanelHybridUI.superclass.Destroy(self)
	self.Content.closeBtn:Destroy()
	self.Content.inviteNum.Text:Destroy()
	self.Content.inviteNum:Destroy()
	self.Content.number:Destroy()
	self.Content.invitecodeBG.Text:Destroy()
	self.Content.invitecodeBG:Destroy()
	self.Content.Text:Destroy()
	self.Content.tittleBG.Text:Destroy()
	self.Content.tittleBG:Destroy()
	self.Content:Destroy()
	self.Content.closeBtn = nil
	self.Content.inviteNum.Text = nil
	self.Content.inviteNum = nil
	self.Content.number = nil
	self.Content.invitecodeBG.Text = nil
	self.Content.invitecodeBG = nil
	self.Content.Text = nil
	self.Content.tittleBG.Text = nil
	self.Content.tittleBG = nil
	self.Content = nil
end